using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using WebApplication4.Models;

namespace WebApplication4.Controllers
{
    public class FlatController : Controller
    {

        public IActionResult RegF() 
        {
            return View(); 
                
        }
        public IActionResult DeleteF() 
        { 
           return View();
        }

        public IActionResult ViewAll()
        {

            FlatCollection mod = GetAppartmentCollectionModel();

            return View(mod.Collection);
        }

        public IActionResult DeleteFlat(int id)
        {
           
                FlatCollection mod = GetAppartmentCollectionModel();

                FlatModel tmpmod = mod.Collection.First(x => x.Id == id);

                if (tmpmod != null)
                {
                    mod.Collection.Remove(tmpmod);
                    ViewBag.result = "Квартира удалена";
                    using (StreamWriter w = new StreamWriter("../Flats.json", false))
                    {
                        w.Write(JsonConvert.SerializeObject(mod).ToString());
                    }
                    return View("Index");
                }
                else
                {
                    ViewBag.result = "Квартира не найдена";
                    return View("Index");
                }
            
        }
        public IActionResult Index()
        {
            return View();
        }

       
        public IActionResult RegisterFlat(int id, int numbersofrooms,  int bildyear,  double amountsquare, int floor)
        {

           FlatCollection model = GetAppartmentCollectionModel();

            var flat = new FlatModel ()
            {
                Id = id,

                NumbersOfRooms = numbersofrooms,

                BildYear = bildyear,

                AmountSquare = amountsquare,

                Floor = floor

            };

            model.Collection.Add(flat);

            using (StreamWriter w = new StreamWriter("../Flats.json", false))
            {
                w.Write(JsonConvert.SerializeObject(model).ToString());
            }
            
            

            ViewData["Result"] = "Новая квартира добавлена";

            return View("Index");
        }

        private FlatCollection GetAppartmentCollectionModel()
        {
            //using (string json = JsonSerializer.Serialize())
           

            using (var f = new StreamReader("../Flats.json"))
            {
                string s = f.ReadToEnd();
                return string.IsNullOrEmpty(s)
                    ? new FlatCollection()
                    : JsonConvert.DeserializeObject<FlatCollection>(s);
            }
        }

    }
}
