using Microsoft.VisualStudio.TestTools.UnitTesting;
using PatientDemographics.Controllers;
using PatientDemographics.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Results;

namespace PatientDemographics.Tests.Controllers
{
    [TestClass]
  public  class PatientDemoGraphicControllerTest
    {
        [TestMethod]
        public void PatientDemoGraphicIdSuccess()
        {
            // Set up Prerequisites   
            var controller = new PatientDemoGraphicController();
            // Act on Test  
            var response = controller.GetPatientPersonalDetails();
            var contentResult = response as OkNegotiatedContentResult<PatientDetails>; 
            // Assert the result  
            Assert.IsNotNull(contentResult);
            Assert.IsNotNull(contentResult.Content);
            //Assert.AreEqual(1, contentResult.Content);
        }
    }
}
