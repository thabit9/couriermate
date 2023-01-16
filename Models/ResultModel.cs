using System.Collections.Generic;
using CourierMate.Models.Collection;
using CourierMate.Models.Delivery;
using CourierMate.Models.GlobalData;
using CourierMate.Models.Quotation;
using CourierMate.Models.Tracking;

namespace CourierMate.Models
{
    public abstract class _results
    {
        public string response_message { get; set; }
        public int response_code { get; set; }
        public int record_count { get; set; }
    }
    // _global data
    public class ResultModelTowns: _results{
        public List<Town> records { get; set; }
    }
    public class ResultModelServices: _results{
        public List<Servicex> records { get; set; }
    }
    public class ResultModelOtherServices: _results{
        public List<OtherServicex> records { get; set; }
    }
    public class ResultModelAddress: _results{
        public List<Address> records { get; set; }
    }

    // _quotation
    public class ResultModelQuote: _results{
        public List<Quote> records { get; set; }
    }
    public class ResultModelAccept: _results{
        public List<AcceptQuotex> records { get; set; }
    }
    public class ResultModelQuoteDoc: _results{
        public List<QuoteDoc> records { get; set; }
    }
    public class ResultModelQuoteChange: _results{
        public List<QuoteCharge> records { get; set; }
    }

    // _collection
    public class ResultModelCollection: _results{
        public List<Collectionx> records { get; set; }
    }
    public class ResultModelCollectionStatus: _results{
        public List<CollectionStatus> records { get; set; }
    }
    public class ResultModelCollectionDoc: _results{
        public List<CollectionDoc> records { get; set; }
    }

    // _delivery 
    public class ResultModelDelivery: _results{
        public List<Deliveryx> records { get; set; }
    }
    public class ResultModelDeliveryPod: _results{
        public List<DeliveryPod> records { get; set; }
    }
    public class ResultModelDeliveryPodImage: _results{
        public List<DeliveryPodImage> records { get; set; }
    }
    public class ResultModelDeliveryDoc: _results{
        public List<DeliveryDoc> records { get; set; }
    }
    public class ResultModelDeliveryNo: _results{
        public List<DeliveryNo> records { get; set; }
    }

    // _tracking
    public class ResultModelTracking: _results{
        public List<Trackingx> records { get; set; }
    }
}