using RestSharp;
using Newtonsoft.Json;
using RESTAPI_ClassLibrary;

namespace RESTApplication
{
    public partial class Form1 : Form
    {
        EmpConnection.Rootobject result; //store result of the API conversion
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            getData();
        }

        private void getData()
        {
            var client = new RestClient("https://dummy.restapiexample.com/api/v1/");
            var request = new RestRequest("employees"); //last bit of address
            var response = client.Execute(request);

            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                string rawResponse = response.Content;

                result = JsonConvert.DeserializeObject<EmpConnection.Rootobject>(rawResponse);

                if (result != null)
                {
                    foreach (var obj in result.data)
                    {
                        listBox1.Items.Add(obj.employee_name);
                    }
                }
            }


        }
    }
}