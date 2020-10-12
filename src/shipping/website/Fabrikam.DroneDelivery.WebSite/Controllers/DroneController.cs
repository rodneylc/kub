﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Fabrikam.DroneDelivery.ApiClient;
using Fabrikam.DroneDelivery.ApiClient.Model;
using Fabrikam.DroneDelivery.WebSite.Accessors;
using Fabrikam.DroneDelivery.WebSite.Interfaces;
using Fabrikam.DroneDelivery.WebSite.Manager;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace Fabrikam.DroneDelivery.WebSite.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DroneController : ControllerBase
    {
        private const string apiUrl = "https://russdronebasic2-ingest-dev.eastus.cloudapp.azure.com/";

        private IDroneManager _droneManager;
        private IConfiguration _configuration;

        public DroneController(IConfiguration iconfiguration)
        {
            //IDroneManager droneManager
            _droneManager = new DroneManager(new TrackingAccessor(new TrackingClient(apiUrl)));
            _configuration = iconfiguration;
        }

        /// <summary>
        /// Returns the delivery 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{deliveryId}")]
        public async Task<Delivery> GetDelivery(Guid deliveryId)
        {
            return await this._droneManager.GetDelivery(deliveryId);
        }

        /// <summary>
        /// Returns current location of the drone
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{deliveryId}/dronelocation")]
        public async Task<DroneLocation> GetDroneLocation(Guid deliveryId)
        {
            return await this._droneManager.GetDroneLocation(deliveryId);
        }     
        
        /// <summary>
        /// Accepts post request with content from request body
        /// </summary>
        /// <param name="content"></param>
        /// <returns></returns>        
        [HttpPost("deliveryrequest")]
        public async Task<DeliveryResponse> AddDeliveryRequest([FromBody] DeliveryRequest deliveryRequest)
        {
            return await this._droneManager.AddDeliveryRequest(deliveryRequest);
        }
        /// <summary>
        /// Returns Bing map key
        /// </summary>
        /// <returns></returns>
        [HttpGet("bingMapKey")]
        public string GetBingMapKey()
        {
            return _configuration["BingMapKey"];  
        }
    }
}