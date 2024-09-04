﻿using gip.core.autocomponent;
using gip.core.communication;
using gip.core.datamodel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace vaxtor.mes.processapplication
{
    [ACClassInfo(Const.PackName_VarioSystem, "en{'VaxOCR'}de{'VaxOCR'}", Global.ACKinds.TPABGModule, Global.ACStorableTypes.Required, false, false)]
    public class VaxOCR : PAClassAlarmingBase
    {
        #region c'tors

        public VaxOCR(ACClass acType, IACObject content, IACObject parentACObject, ACValueList parameter, string acIdentifier = "") : 
            base(acType, content, parentACObject, parameter, acIdentifier)
        {
        }

        public override bool ACInit(Global.ACStartTypes startChildMode = Global.ACStartTypes.Automatic)
        {
            return base.ACInit(startChildMode);
        }

        public override bool ACPostInit()
        {
            bool result = base.ACPostInit();

            _QueryParams = new Dictionary<string, string>
            {
                { QueryParamPage, PageToRetrive.ToString() },
                { QueryParamID, LastRetrivedID.ValueT }
            };

            _ShutdownEvent = new ManualResetEvent(false);
            _PollThread = new ACThread(Poll);
            _PollThread.Name = "ACUrl:" + this.GetACUrl() + ";Poll();";
            _PollThread.Start();

            return result;
        }

        public override bool ACDeInit(bool deleteACClassTask = false)
        {
            return base.ACDeInit(deleteACClassTask);
        }

        public const string QueryParamLimit = "limit";
        public const string QueryParamPage = "page";
        public const string QueryParamID = "id";

        #endregion

        #region Properties

        private Dictionary<string, string> _QueryParams;

        [ACPropertyInfo(true, 400, "Config", "en{'Polling [ms]'}de{'Abfragezyklus [ms]'}", DefaultValue = 200)]
        public int PollingInterval { get; set; }

        [ACPropertyBindingSource(9999, "Error", "en{'VaxOCR alarm'}de{'VaxOCR Alarm'}", "", false, false)]
        public IACContainerTNet<PANotifyState> VaxOCRAlarm { get; set; }

        private ACRef<ACRestClient> _Client;
        public ACRestClient Client
        {
            get
            {
                if (_Client != null)
                    return _Client.ValueT;
                var client = FindChildComponents<ACRestClient>(c => c is ACRestClient).FirstOrDefault();
                if (client != null)
                {
                    // TODO: find right place for this
                    //ServicePointManager.ServerCertificateValidationCallback = delegate (object s, X509Certificate certificate, X509Chain chain, SslPolicyErrors sslPolicyErrors) { return true; };
                    _Client = new ACRef<ACRestClient>(client, this);
                    return _Client.ValueT;
                }
                return null;
            }
        }

        [ACPropertyBindingSource(9999, "Error", "en{'Last retrived container ID'}de{'Last retrived container ID'}", "", true, true)]
        public IACContainerTNet<string> LastRetrivedID
        {
            get;
            set;
        }

        [ACPropertyInfo(true, 9999, "Config", "en{'Limit registers per page'}de{'Limit registers per page'}", DefaultValue = 5)]
        public int LimitRegistersPerPage
        {
            get;
            set;
        }

        [ACPropertyInfo(true, 9999, "Config", "en{'Page to retrive'}de{'Page to retrive'}", DefaultValue = 5)]
        public int PageToRetrive
        {
            get;
            set;
        }

        private string _BaseUri;
        public string BaseUri
        {
            get
            {
                if (_BaseUri == null)
                {
                    _BaseUri = Client?.ServiceUrl;
                }
                return _BaseUri;
            }
        }
        

        #endregion


        #region Methods

        protected ManualResetEvent _ShutdownEvent;
        ACThread _PollThread;
        private void Poll()
        {
            try
            {
                while (!_ShutdownEvent.WaitOne(PollingInterval, false))
                {
                    _PollThread.StartReportingExeTime();


                    _PollThread.StopReportingExeTime();
                }
            }
            catch (ThreadAbortException ec)
            {
                VaxOCRAlarm.ValueT = PANotifyState.AlarmOrFault;
                if (IsAlarmActive(nameof(VaxOCRAlarm), ec.Message) == null)
                {
                    Messages.LogException(GetACUrl(), $"{nameof(VaxOCRAlarm)}.{nameof(Poll)}(20)", ec);
                }
                OnNewAlarmOccurred(VaxOCRAlarm, ec.Message, true);
            }
        }

        private void RetriveDBRecognitions()
        {
            string uri = GenerateURI();
            

        }

        private string GenerateURI()
        {
            if (BaseUri == null)
                return null;

            _QueryParams[QueryParamID] = LastRetrivedID.ValueT;

            UriBuilder uriBuilder = new UriBuilder(BaseUri);
            uriBuilder.Query = new FormUrlEncodedContent(_QueryParams).ReadAsStringAsync().Result;

            return uriBuilder.Uri.ToString();
        }

        #endregion
    }
}