﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MasterDetail.WebApp.Models;

namespace MasterDetail.WebApp.Entity
{
    public class Repository: IRepository
    {
        private EfContext context = new EfContext();

        public IEnumerable<QrTracking> Trackings
        {
            get { return context.QrTrackings; }
        }

        public QrTracking Get(int id)
        {
            return context.QrTrackings.Find(id);
        }

        public async Task<int> SaveTrackingAsync(QrTracking tracking)
        {
            if (tracking.Id == 0)
            {
                context.QrTrackings.Add(tracking);
            }
            else
            {
                var dbEntry = context.QrTrackings.Find(tracking.Id);
                if (dbEntry != null)
                {
                    dbEntry.OrderDate = tracking.OrderDate;
                    dbEntry.MoNum = tracking.MoNum;
                    dbEntry.QrShift = tracking.QrShift;
                    dbEntry.QrOperators = tracking.QrOperators;
                    dbEntry.QrComments = tracking.QrComments;
                }
            }
            return await context.SaveChangesAsync();
        }

        public IEnumerable<CodeVm> Codes(int id)
        {
            var tracking = context.QrTrackings.Find(id);
            if (tracking == null)
                return null;
            var list = tracking.QrCodes.ToList();
            return list.Select(x => new CodeVm { Id = x.Id, Barcode = x.Barcode, QrCodeLine = x.QrCodeLine, ScanDateTime = x.ScanDateTime });
        }

        public QrCode SaveCode(int trackingId, string barcode, string qrCodeLine)
        {
            var tracking = context.QrTrackings.Find(trackingId);
            if (tracking == null)
                return null;
            var code = new QrCode {Barcode = barcode, QrCodeLine = qrCodeLine, ScanDateTime = DateTime.Now };
            tracking.QrCodes.Add(code);
            context.SaveChanges();
            return code;
        }

        public void DeleteCode(int barcodeId)
        {
            var code = context.QrCodes.Find(barcodeId);
            if (code != null)
            {
                context.QrCodes.Remove(code);
                context.SaveChanges();
            }
        }
    }
}