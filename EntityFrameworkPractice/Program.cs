using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FuneralHome.Controllers;
using FuneralHome.Models.PostModels;
using FuneralHome.Models.ViewModels;

namespace EntityFrameworkPractice
{
    class Program
    {
        static void Main(string[] args)
        {
            var clientController = new ClientControllers();

            var clientModel = new ClientPostModel()
            {
                Address = "1232123",
                FirstName = "James",
                LastName = "Brown",
                MiddleName = "Bunny",
                Phone = "+1934267342",
                DeathCertificateNumber = 12345
            };



            clientController.Create(clientModel);
            var models = clientController.GetAll();

            var updatedModel = new ClientViewModel()
            {
                Id = 2,
                Address = "Won't tell u",
                FirstName = "John",
                LastName = "Wick",
                MiddleName = "Don't joke with Bunny",
                Phone = "+1934267342",
                DeathCertificateNumber = 11111
            };

            //clientController.Update(updatedModel);
            //var updatedModels = clientController.GetAll();

            //var getClientById = clientController.GetById(1);

            //var deletedclient = clientController.DeleteById(1);
        }
    }
}
