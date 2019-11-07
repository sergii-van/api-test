using System;
using System.Collections.Generic;
using System.Linq;
using ApiTest.Core.Helpers;
using ApiTest.Core.Models;
using AutoFixture;
using Xunit;

namespace ApiTest.Tests.Core.Helpers
{
    public class AttendanceHelperTests
    {
        private Fixture _fixture = new Fixture();

        [Fact]
        public void MustThrowWhenStudentIsNull()
        {
            Assert.Throws<ArgumentNullException>(() => AttendanceHelper.AddStudentAttendance(null, new Dictionary<int, int>()));
        }

        [Fact]
        public void MustThrowWhenIncorrectStartEndDates()
        {
            var student = _fixture.Build<Student>().With(x => x.StartYear, 2010).With(x => x.EndYear, 2000).Create();

            Assert.Throws<ArgumentException>(() => AttendanceHelper.AddStudentAttendance(student, new Dictionary<int, int>()));
        }

        [Fact]
        public void MustIncludeOneYear()
        {
            var student = _fixture.Build<Student>().With(x => x.StartYear, 2010).With(x => x.EndYear, 2010).Create();
            var dictionary = new Dictionary<int, int>();

            AttendanceHelper.AddStudentAttendance(student, dictionary);

            Assert.Single(dictionary);
            Assert.Equal(1, dictionary.Values.First());
        }

        [Fact]
        public void MustIncludeSeveralYears()
        {
            var student = _fixture.Build<Student>().With(x => x.StartYear, 2010).With(x => x.EndYear, 2012).Create();
            var dictionary = new Dictionary<int, int>();

            AttendanceHelper.AddStudentAttendance(student, dictionary);

            Assert.Equal(3, dictionary.Count);
        }
    }
}
