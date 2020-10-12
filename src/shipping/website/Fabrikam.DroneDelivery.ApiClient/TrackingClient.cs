﻿using Fabrikam.DroneDelivery.ApiClient.Model;
using Fabrikam.DroneDelivery.WebSite.Common;
using System;
using System.Threading.Tasks;

namespace Fabrikam.DroneDelivery.ApiClient
{
    public class TrackingClient
    {
        private string _baseUrl;
        
        public TrackingClient(string url)
        {
            _baseUrl = url;
        }

        public async Task<DeliveryResponse> AddDeliveryRequest(DeliveryRequest deliveryRequest)
        {
            string body = string.Empty;
            var delivery = await RestClient.Post<DeliveryResponse>($"{this._baseUrl}/api/deliveryrequests", deliveryRequest);
            return delivery;

        }
        public async Task<Delivery> GetDelivery(Guid deliveryId)
        {
            return await RestClient.Get<Delivery>($"{this._baseUrl}/api/deliveries/{deliveryId}");
        }

        public async Task<DroneLocation> GetDroneLocation(Guid deliveryId)
        {
            var droneLocation = await RestClient.Get<DroneLocation>($"{this._baseUrl}/api/deliveries/{deliveryId}/status");
            return droneLocation;
        }
    }
}