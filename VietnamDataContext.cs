using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using VietnamDMSx.Vietnam.EFModelViews;

namespace VietnamDMSx.Vietnam
{
    public class VietnamDataContext : DbContext 
    {
        public VietnamDataContext(DbContextOptions<VietnamDataContext> options) : base(options)  {  }
        public virtual DbQuery<TopDefectsElement> TopDefectsElements { get; set; }
        public virtual DbQuery<BathLifeOfEtchChemical> BathLifeOfEtchChemicals { get; set; }
        public virtual DbQuery<IChartNickelPlating> IChartNickel { get; set; }
        public virtual DbQuery<RawDataElements> RawDataElement{ get; set; }
        public virtual DbQuery<IChartMamModel> ChartMamModels { get; set; }
        public virtual DbQuery<DrawHistogram> DrawHistograms { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Query<RawDataElements>().ToView("v_tbRawDataElementTapeTestSPC");

            modelBuilder.Query<BathLifeOfEtchChemical>().ToView("v_BathLifeOfEtchChemical");

            modelBuilder.Query<IChartMamModel>().ToView("v_IChartMAM");

            modelBuilder.Query<IChartNickelPlating>().ToView("v_IChartNickelPlating");

            modelBuilder.Query<DrawHistogram>().ToView("v_HistogramMAM_Type");

            modelBuilder.Query<TopDefectsElement>().ToView("v_TopDefectsElement");
        }
    }
}
