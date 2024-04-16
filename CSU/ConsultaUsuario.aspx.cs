using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Newtonsoft.Json;
using RestSharp;
using pruebaRest;
using pruebaRest.CSD;

namespace pruebaRest.CSU
{
    public partial class ConsultaUsuario : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnConsultar_Click(object sender, EventArgs e)
        {
            // conexion al servicio web y solicitando datos con el get 
            
            RestClient client = new RestClient("https://randomuser.me/api/");
            string Respuesta;

            RestRequest request = new RestRequest();
            // los gatos se reciben en esta variable 
            var response = client.Get(request);

            Respuesta = response.Content;

            // desiarializarlo 

            Resultados oResultados = JsonConvert.DeserializeObject<Resultados>(Respuesta);
            // obtencion del primer dato 
            Usuario oUsuario = oResultados.results[0];

            // valores de los atributos que se han devuelto 
            imgUsuario.ImageUrl = oUsuario.picture.large;
            txtTitulo.Text = oUsuario.name.title;
            txtNombre.Text = oUsuario.name.first;
            txtApellido.Text = oUsuario.name.last;
            txtUsuario.Text = oUsuario.Login.username;
            txtpassw.Text = oUsuario.Login.password;
            txtfechaNacim.Text = oUsuario.dob.date;
            txtPhone.Text = oUsuario.phone.ToString();

        }
    }
}