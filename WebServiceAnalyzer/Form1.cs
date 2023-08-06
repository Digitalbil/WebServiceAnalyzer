using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Web.Services.Description;
using System.Security.Policy;
using static WebServiceAnalyzer.WebServiceInfo;
using static WebServiceAnalyzer.WebServiceInfo.WebMethodInfo;

namespace WebServiceAnalyzer
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void buttonGetUrlOrWsdl_Click(object sender, EventArgs e)
        {
            string wsdlFile = textBoxUrl.Text;
            ServiceDescriptionSpike(wsdlFile);
        }


        public void ServiceDescriptionSpike(string wsUrl)
        {
            string url = wsUrl;

            WebServiceInfo webServiceInfo = WebServiceInfo.OpenWsdl(new Uri(url));

            labelWebserviceName.Text = string.Format("{0}", webServiceInfo.Url);

            List<string> methodParameters = new List<string>();

            foreach (WebMethodInfo method in webServiceInfo.WebMethods)
            {
                string methodWithParameters = string.Format("methodname={0}", method.Name);
                string paramString = null;
                foreach (Parameter parameter in method.InputParameters)
                {
                    paramString = string.Format("&name={0}&type={1}", parameter.Name, parameter.Type);
                }
                string finalParamsString = methodWithParameters + paramString;
                listBoxMethods.Items.Add(finalParamsString);

                string outputsString = "outputs =";
                foreach (Parameter parameter in method.OutputParameters)
                {
                    outputsString += string.Format(" name={0}&type={1}", parameter.Name, parameter.Type);
                }
                listBoxMethods.Items.Add(outputsString);

            }
        }
    }

    public class WebServiceInfo
    {
        WebMethodInfoCollection webMethods = new WebMethodInfoCollection();
        Uri url;
        static Dictionary<string, WebServiceInfo> webServiceInfos = new Dictionary<string, WebServiceInfo>();

        private WebServiceInfo(Uri url)
        {
            if (url == null)
                throw new ArgumentNullException("url");
            Url = url;
            webMethods = GetWebServiceDescription(url);
        }

        public static WebServiceInfo OpenWsdl(Uri url)
        {
            WebServiceInfo webServiceInfo;
            if (!webServiceInfos.TryGetValue(url.ToString(), out webServiceInfo))
            {
                webServiceInfo = new WebServiceInfo(url);
                webServiceInfos.Add(url.ToString(), webServiceInfo);
            }
            return webServiceInfo;
        }

        public static WebServiceInfo OpenWsdl(string url)
        {
            Uri uri = new Uri(url);
            return OpenWsdl(uri);
        }

        private WebMethodInfoCollection GetWebServiceDescription(Uri url)
        {
            UriBuilder uriBuilder = new UriBuilder(url);
            uriBuilder.Query = "WSDL";

            WebMethodInfoCollection webMethodInfoCollection = new WebMethodInfoCollection();

            HttpWebRequest webRequest = (HttpWebRequest)WebRequest.Create(uriBuilder.Uri);
            webRequest.ContentType = "text/xml;charset=\"utf-8\"";
            webRequest.Method = "GET";
            webRequest.Accept = "text/xml";

            ServiceDescription serviceDescription;

            using (System.Net.WebResponse response = webRequest.GetResponse())
            using (System.IO.Stream stream = response.GetResponseStream())
            {
                serviceDescription = ServiceDescription.Read(stream);
            }

            foreach (PortType portType in serviceDescription.PortTypes)
            {
                foreach (Operation operation in portType.Operations)
                {
                    string operationName = operation.Name;
                    string inputMessageName = operation.Messages.Input.Message.Name;
                    string outputMessageName = operation.Messages.Output.Message.Name;

                    string inputMessagePartName = serviceDescription.Messages[inputMessageName].Parts[0].Element.Name;
                    string outputMessagePartName = serviceDescription.Messages[outputMessageName].Parts[0].Element.Name;

                    Parameter[] inputParameters = GetParameters(serviceDescription, inputMessagePartName);
                    Parameter[] outputParameters = GetParameters(serviceDescription, outputMessagePartName);

                    WebMethodInfo webMethodInfo = new WebMethodInfo(operation.Name, inputParameters, outputParameters);
                    webMethodInfoCollection.Add(webMethodInfo);
                }
            }

            return webMethodInfoCollection;
        }

        private static Parameter[] GetParameters(ServiceDescription serviceDescription, string messagePartName)
        {
            List<Parameter> parameters = new List<Parameter>();

            Types types = serviceDescription.Types;
            System.Xml.Schema.XmlSchema xmlSchema = types.Schemas[0];

            foreach (object item in xmlSchema.Items)
            {
                System.Xml.Schema.XmlSchemaElement schemaElement = item as System.Xml.Schema.XmlSchemaElement;
                if (schemaElement != null)
                {
                    if (schemaElement.Name == messagePartName)
                    {
                        System.Xml.Schema.XmlSchemaType schemaType = schemaElement.SchemaType;
                        System.Xml.Schema.XmlSchemaComplexType complexType = schemaType as System.Xml.Schema.XmlSchemaComplexType;
                        if (complexType != null)
                        {
                            System.Xml.Schema.XmlSchemaParticle particle = complexType.Particle;
                            System.Xml.Schema.XmlSchemaSequence sequence = particle as System.Xml.Schema.XmlSchemaSequence;
                            if (sequence != null)
                            {
                                foreach (System.Xml.Schema.XmlSchemaElement childElement in sequence.Items)
                                {
                                    string parameterName = childElement.Name;
                                    string parameterType = childElement.SchemaTypeName.Name;
                                    parameters.Add(new Parameter(parameterName, parameterType));
                                }
                            }
                        }
                    }
                }
            }
            return parameters.ToArray();
        }


        public WebMethodInfoCollection WebMethods
        {
            get { return webMethods; }
        }

        public Uri Url
        {
            get { return url; }
            set { url = value; }
        }


        public class WebMethodInfo
        {
            string name;
            Parameter[] inputParameters;
            Parameter[] outputParameters;

            public WebMethodInfo(string Name, Parameter[] InputParameters, Parameter[] OutputParameters)
            {
                name = Name;
                inputParameters = InputParameters;
                outputParameters = OutputParameters;
            }

            public string Name
            {
                get { return name; }
            }

            public Parameter[] InputParameters
            {
                get { return inputParameters; }
            }

            public Parameter[] OutputParameters
            {
                get { return outputParameters; }
            }

            public class WebMethodInfoCollection : KeyedCollection<string, WebMethodInfo>
            {
                public WebMethodInfoCollection() : base() { }

                protected override string GetKeyForItem(WebMethodInfo webMethodInfo)
                {
                    return webMethodInfo.Name;
                }                               
            }

            public struct Parameter
            {
                public Parameter(string name, string type)
                {
                    this.Name = name;
                    this.Type = type;
                }

                public string Name;
                public string Type;
            }
        }
    }
}

