using DomainModel.APIGoogle;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace RestGoogle.Controllers
{
    public class ResultController : ApiController
    {
        // GET: api/Result/55,212/28,125
        [Route("api/Result/{longitude}/{latitude}")]        
        public IEnumerable<Result> Get(string longitude, string latitude)
        {
            List<Result> lstResult = new List<Result>();

            Result r = new Result();
            r.id = "1";            
            r.name = "Restaurante Flor de Pimenta";
            r.reference = "Comida light, orgânica e vegetariana em pequeno e aconchegante restaurante de estilo contemporâneo e alegre.";
            r.place_id = "Av, Marechal Floriano, 13, Centro, Rio de Janeiro - RJ, 20080-003";
            r.photos = new List<Photo>();
            Photo p = new Photo();
            p.photo_reference = "Images/rest1.jpg";
            r.photos.Add(p);

            lstResult.Add(r);

            r = new Result();
            r.id = "2";
            r.name = "Vegetariano Social Club ";
            r.reference = "Almoços veganos e orgânicos, mini loja, cursos e delivery de casa pioneira em culinária vegana no Rio.";
            r.place_id = "Rua Conde de Bernadotte, 26 - loja l - Leblon, Rio de Janeiro - RJ, 22430-200";
            r.photos = new List<Photo>();
            p = new Photo();
            p.photo_reference = "Images/rest2.jpg";
            r.photos.Add(p);

            lstResult.Add(r);

            r = new Result();
            r.id = "3";
            r.name = "Teva ";
            r.reference = "Self-service na hora do almoço, com pratos vegetarianos e orgânicos, em ambiente rústico de antigo casarão.";
            r.place_id = "R. Primeiro de Março, 24 - Centro, Rio de Janeiro - RJ, 20010-000";
            r.photos = new List<Photo>();
            p = new Photo();
            p.photo_reference = "Images/rest3.jpg";
            r.photos.Add(p);

            lstResult.Add(r);

            r = new Result();
            r.id = "4";
            r.name = "Restaurante Mitsumo ";
            r.reference = "Café da manhã, lanches, almoços e tortas, sem qualquer produto de origem animal, em casa verde com samambaias.";
            r.place_id = "R. Voluntários da Pátria, 402 - Loja B - Botafogo, Rio de Janeiro - RJ, 22270-016";
            r.photos = new List<Photo>();
            p = new Photo();
            p.photo_reference = "Images/rest4.jpg";
            r.photos.Add(p);

            lstResult.Add(r);

            return lstResult;

            #region "Desenvolver"
            //TODO:
            // using (var client = new HttpClient())
            //{
            //    var response = await client.GetStringAsync(string.Format("https://maps.googleapis.com/maps/api/place/findplacefromtext/json?input=mongolian%20grill&inputtype=textquery&fields=photos,formatted_address,name,opening_hours,rating&locationbias=circle:2000@47.6918452,-122.2226413&key=AIzaSyDb2vbyv0FOWvFqX-lhYfkjqnOOCiUs_Xw"));

            //    var result = JsonConvert.DeserializeObject<PlacesApiQueryResponse>(response).results;

            //    return result;
            //}
            #endregion
        }

        // GET: api/Result/5
        public string Get(int id)
        {
            throw new Exception("Method is not implemented!");
        }

        // POST: api/Result
        public void Post([FromBody]string value)
        {
            throw new Exception("Method is not implemented!");
        }

        // PUT: api/Result/5
        public void Put(int id, [FromBody]string value)
        {
            throw new Exception("Method is not implemented!");
        }

        // DELETE: api/Result/5
        public void Delete(int id)
        {
            throw new Exception("Method is not implemented!");
        }
    }
}
