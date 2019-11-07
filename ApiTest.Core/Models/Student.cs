﻿namespace ApiTest.Core.Models
{
    public class Student
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int StartYear { get; set; }

        public int EndYear { get; set; }

        public float[] GPARecord { get; set; }
    }
}
