using System.Collections.Generic;

namespace docker.worker.manager.SharedModel.CovidService
{
    public class Patient
    {
        public string agebracket { get; set; }
        public string contractedfromwhichpatientsuspected { get; set; }
        public string currentstatus { get; set; }
        public string dateannounced { get; set; }
        public string detectedcity { get; set; }
        public string detecteddistrict { get; set; }
        public string detectedstate { get; set; }
        public string entryid { get; set; }
        public string gender { get; set; }
        public string nationality { get; set; }
        public string notes { get; set; }
        public string numcases { get; set; }
        public string patientnumber { get; set; }
        public string source1 { get; set; }
        public string source2 { get; set; }
        public string source3 { get; set; }
        public string statecode { get; set; }
        public string statepatientnumber { get; set; }
        public string statuschangedate { get; set; }
        public string typeoftransmission { get; set; }
    }

    public class CovidData
    {
        public IList<Patient> raw_data { get; set; }
    }
}
