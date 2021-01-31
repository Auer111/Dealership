using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dealership.Models
{

    public class FraizerVehicle
    {
        [JsonProperty("Stock#")]
        public int Stock { get; set; }
        public int VehicleYear { get; set; }
        public string VehicleMake { get; set; }
        public object VehicleModel { get; set; }
        public string VehicleVIN { get; set; }
        public int Mileage { get; set; }
        [JsonProperty("New/Used")]
        public string NewUsed { get; set; }
        public int Cylinders { get; set; }
        public int Weight { get; set; }
        public string VehicleColor { get; set; }
        public string VehicleColor2 { get; set; }
        public string VehicleFeatures { get; set; }
        public int RetailPrice { get; set; }
        public int InternetPrice { get; set; }
        [JsonProperty("OtherPrice/Cost")]
        public int OtherPriceCost { get; set; }
        public string VehicleSource { get; set; }
        [JsonProperty("GPSSerial#")]
        public object GPSSerial { get; set; }
        public int BuyFee { get; set; }
        public int MarketValue { get; set; }
        public string VehicleStyle { get; set; }
        public string Certified { get; set; }
        public string Buyer { get; set; }
        public string DriveTrain { get; set; }
        public object LocationCode { get; set; }
        public int OriginalCost { get; set; }
        public string BodyType { get; set; }
        public string Engine { get; set; }
        public string Transmission { get; set; }
        public int DesiredDownPayment { get; set; }
        public int FloorPlanAmount { get; set; }
        public double FloorPlanCost { get; set; }
        public string FloorPlanCompany { get; set; }
        public string FloorPlanOpenedDate { get; set; }
        public string FloorPlanClosedDate { get; set; }
        public int PreviousOwners { get; set; }
        public string PurchaseDate { get; set; }
        public string VehicleNotes { get; set; }
        public string Vendor { get; set; }
        public string TitleIn { get; set; }
        public object TitleNumber { get; set; }
        public string TitleState { get; set; }
        public string DuplicateKeys { get; set; }
        public int Photos { get; set; }
        public string VehicleSettoUpload { get; set; }
        public string DraftNumber { get; set; }
        public string DateDraftPaid { get; set; }
        public int LotFee { get; set; }
        public int AddedCosts { get; set; }
        public int LaborCosts { get; set; }
        public string Tag { get; set; }
        public string Inspected { get; set; }
        public object InspectionNumber { get; set; }
        public string InspectionDate { get; set; }
        public string InspectedBy { get; set; }
        public object IgnitionKeyCode { get; set; }
        public int GLPurchaseAccount { get; set; }
        [JsonProperty("Sales/InternetComments")]
        public string SalesInternetComments { get; set; }
        public string VehicleType { get; set; }
        public string FuelType { get; set; }
        public string NADADateRetrieved { get; set; }
        public int NADAMSRP { get; set; }
        public int NADAAverageMileage { get; set; }
        public int NADAMileageAdjustment { get; set; }
        public int NADARetailValue { get; set; }
        public int NADALoanValue { get; set; }
        public int NADACleanTradeValue { get; set; }
        public int NADAAverageTradeValue { get; set; }
        public int NADARoughTradeValue { get; set; }
        public int NADASelectedOptionalEquipmentRetailTotal { get; set; }
        public int NADASelectedOptionalEquipmentLoanTotal { get; set; }
        public int NADASelectedOptionalEquipmentTradeTotal { get; set; }
        public int NADALowAuctionValue { get; set; }
        public int NADAAverageAuctionValue { get; set; }
        public int NADAHighAuctionValue { get; set; }
        public string ExpirationDate { get; set; }
        public string PurchaseNotes { get; set; }
        public object DoorKeyCode { get; set; }
        public object ValetKeyCode { get; set; }
        public string SiriusXMRadioExists { get; set; }
        public string ReadyToSellDate { get; set; }
        public int WholesalePrice { get; set; }
        public int DaysOnLot { get; set; }
        public double TotalCost { get; set; }
        public object Year { get; set; }
        public string Make { get; set; }
        public object Model { get; set; }
        public string VIN { get; set; }
        public int Mileage__1 { get; set; }
        public string Color { get; set; }
        public string Color2 { get; set; }
        public int RetailPrice__1 { get; set; }
        public string BodyType__1 { get; set; }
        public string Style { get; set; }
        public int Weight__1 { get; set; }
        public string Condition { get; set; }
        public string Transmission__1 { get; set; }
        public string Engine__1 { get; set; }
        public string FuelType__1 { get; set; }
        public int Cylinder { get; set; }
        public string Features { get; set; }
        public int FloorPlanPrincipalOwed { get; set; }
        public string VendorAddress { get; set; }
        public string VendorPhoneNumber { get; set; }
        public object Last6VIN { get; set; }
        public int TransmissionSpeed { get; set; }
        public string VideoURL { get; set; }
        [JsonProperty("Trade-InVIN")]
        public string TradeInVIN { get; set; }
        [JsonProperty("Trade-In2VIN")]
        public string TradeIn2VIN { get; set; }
        [JsonProperty("Trade-InLast6VIN")]
        public string TradeInLast6VIN { get; set; }
        [JsonProperty("Trade-In2Last6VIN")]
        public string TradeIn2Last6VIN { get; set; }
        public int MSRP { get; set; }
    }

}
