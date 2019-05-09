# VNDMSCharts
Documentation on QV Charting

By isolating the data, creating models over our views, then accessing the views. It allows us to build custom data models to add or remove the fields we do not want from our view without directly modifying the actual view.

Think of it as a Model for the View to be passed into.

For example

TopDefectElements
```
public class RawDataElements
    {
        public long Id { get; set; }
        public DateTime? Date { get; set; }
        public string Part { get; set; }
        public string Wo { get; set; }
        public string Lot { get; set; }
        public string Plate { get; set; }
        public string OperatorId { get; set; }
        public int? F2 { get; set; }
        public int? EngIndex { get; set; }
        public string Note2 { get; set; }
        public string Rs2 { get; set; }
        public int? F3 { get; set; }
        public string Note3 { get; set; }
        public string Rs3 { get; set; }
        public string Family { get; set; }
        public string Type { get; set; }
        public decimal USL { get; set; }
    }
```    
In our Context we will tell the program that our Model is represented as the View in the Database, we do so like this.
 public virtual DbQuery<TopDefectsElement> TopDefectsElements { get; set; } - We use DbQuery to Define that we are calling a view.
 modelBuilder.Query<TopDefectsElement>().ToView("v_TopDefectsElement"); - We then get the name of the ACTUAL view and pass it as a string paramater. "v_TopDefectsElement"

In our Extention Method we call
```
  public static class VNDataExtensions
    {
        public static async Task<List<RawDataElements>> RawData(this VietnamDataContext db, string type, string family)
        {
            var RawData = await db.RawDataElement.Where(x => x.Type == type & x.Family == family).Where(x => x.EngIndex != null).OrderBy(y => y.Date).ToListAsync();
            if (type == null && family == null)
            {
                RawData = await db.RawDataElement.ToListAsync();
            }
            return RawData;
        }
        
    }
```

And we call this in our controller.
```
 public class ChartDataController : Controller
    {
        private VietnamDataContext db;
        public ChartDataController(VietnamDataContext db)
        {
            this.db = db;
        }
        [Route("{type}/{family}")]
        public async Task<List<RawDataElements>> RawData(string type, string family)
        {
            return await db.RawData(type, family);
        }
    }
```


Now we can either call all the data by accessing the link

DataAPI/vn/RawElements/ (in my case)
Now you can do stuff like this

DataAPI/vn/RawElements/N/MAM
DataAPI/vn/RawElements/P/MAM
DataAPI/vn/RawElements/P/Plated
DataAPI/vn/RawElements/N/Plated

Returning only the data we need for our charting solutions.
```
{"id":466,"date":"2013-11-23T00:00:00","part":"486-4001-022","wo":"37406","lot":"WUN775D","plate":"+1","operatorId":"960","f2":null,"engIndex":null,"note2":"","rs2":"","f3":null,"note3":"","rs3":"","family":"MAM","type":"N","usl":6.00000}


```


