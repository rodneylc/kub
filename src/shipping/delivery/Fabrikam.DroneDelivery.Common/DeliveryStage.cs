// ------------------------------------------------------------
//  Copyright (c) Microsoft Corporation.  All rights reserved.
//  Licensed under the MIT License (MIT). See License.txt in the repo root for license information.
// ------------------------------------------------------------

namespace Fabrikam.DroneDelivery.Common
{
    public enum DeliveryStage
    {
        Created,
        Rescheduled,
        HeadedToPickup,
        HeadedToDropoff,
        Completed,
        Cancelled
    }
}
