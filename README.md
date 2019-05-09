# VNDMSCharts
Documentation on QV Charting

By isolating the data, creating models over our views, then accessing the views. It allows us to build custom data models to add or remove the fields we do not want from our view without directly modifying the actual view.

Think of it as a Model for the View to be passed into.

For example

TopDefectElements

public class TopDefectsElement
    {
        public int RowNumber { get; set; }
        public int Quantity { get; set; }
        public int Accum { get; set; }
        public int Acc { get; set; }
        public string NCCode { get; set; }
        public string NCDes { get; set; }
        public string Type { get; set; }
    }
    
In our Context we will tell the program that our Model is represented as the View in the Database, we do so like this.
 public virtual DbQuery<TopDefectsElement> TopDefectsElements { get; set; } - We use DbQuery to Define that we are calling a view.
 modelBuilder.Query<TopDefectsElement>().ToView("v_TopDefectsElement"); - We then get the name of the ACTUAL view and pass it as a string paramater.

In our Extention Method we call
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


And we call this in our controller.
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

Giving us this.

{"rowNumber":1,"quantity":1369775,"accum":1369775,"acc":38,"ncCode":"EWOS","ncDes":"ELEMENT WIDTH OUT OF SPEC","type":"TAN"}



