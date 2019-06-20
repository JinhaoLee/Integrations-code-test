using ChoETL;
using System;
using System.ComponentModel;
using System.Threading;

namespace Integration {
    public class Athlele {
        public static int globalID = -1;

        public int id { get; private set; }

        [ChoCSVRecordField(1, FieldName = "firstName")]
        [DefaultValue("")]
        public string firstName { get; set; }

        [ChoCSVRecordField(2, FieldName = "lastName")]
        [DefaultValue("")]
        public string lastName { get; set; }

        [ChoCSVRecordField(3, FieldName = "middleName")]
        [DefaultValue("")]
        public string middleName { get; set; }

        [ChoCSVRecordField(4, FieldName = "dateOfBirth")]
        [DefaultValue("")]
        public string dateOfBirth { get; set; }

        [ChoCSVRecordField(5, FieldName = "sex")]
        [DefaultValue("")]
        public string sex { get; set; }

        [ChoCSVRecordField(6, FieldName = "height")]
        [DefaultValue("")]
        public string height { get; set; }

        [ChoCSVRecordField(7, FieldName = "sport")]
        [DefaultValue("")]
        public string sport { get; set; }

        public Athlele() {
            this.id = Interlocked.Increment(ref globalID);
        }
    }

}
