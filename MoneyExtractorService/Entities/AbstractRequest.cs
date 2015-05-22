using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MoneyExtractorService.Entities
{
    public abstract class AbstractRequest
    {
        //Construtor
        public AbstractRequest()
        {
            this.ActualValidationMessageList = new List<ErrorReport>();
        }
        internal bool IsValid {
            get {
                this.ActualValidationMessageList.Clear();
                this.Validate();
                return (this.ActualValidationMessageList.Any() == false);
            }
        }
        private List<ErrorReport> ActualValidationMessageList { get; set; }

        internal List<ErrorReport> ValidationMessageList {
            get { return this.ActualValidationMessageList.ToList(); }
        }

        protected abstract void Validate();

        protected void AddError(string fieldName, string message) 
        {
            ErrorReport errorReport = new ErrorReport();
            errorReport.Field = this.GetType().Name + "." + fieldName;
            errorReport.Message = message;

            this.ActualValidationMessageList.Add(errorReport);

        }
    }
}