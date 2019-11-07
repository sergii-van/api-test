using System;
using System.Collections.Generic;
using System.Linq;
using ApiTest.Core.Helpers;
using ApiTest.Core.Models;
using AutoFixture;
using Xunit;

namespace ApiTest.Tests.Core.Helpers.Extensions
{
    public class StudentExtensionsTests
    {
        private Fixture _fixture = new Fixture();

        [Fact]
        public void MustThrowWhenStudentIsNull()
        {
            Student student = null;

            Assert.Throws<ArgumentNullException>(() => student.CalculateOverallGpa());
        }

        [Fact]
        public void MustReturnZeroForOverallWhenNoGradesExist()
        {
            Student student = _fixture.Build<Student>().Create();
            student.GPARecord = new float[0];

            float result = student.CalculateOverallGpa();

            Assert.True(Math.Abs(result) < float.Epsilon);
        }

        [Fact]
        public void MustCalculateAverageProperly()
        {
            Student student = _fixture.Build<Student>().Create();
            student.GPARecord = new[] { 3.1f, 3.2f, 3.3f };

            float result = student.CalculateOverallGpa();

            Assert.True(Math.Abs(3.2f - result) < float.Epsilon);
        }

        [Fact]
        public void MustCalculateGradesInconsistency()
        {
            Student student = _fixture.Build<Student>().Create();
            student.GPARecord = new[] { 1f, 3.2f, 3.3f, 3.4f, 2, 5.1f, 2.7f };

            float result = student.CalculateGradesInconsistency();

            Assert.True(Math.Abs(4.1f - result) < float.Epsilon);
        }

        [Fact]
        public void MustReturnZeroWhenOnlyOneGradeExist()
        {
            Student student = _fixture.Build<Student>().Create();
            student.GPARecord = new[] { 1f };

            float result = student.CalculateGradesInconsistency();

            Assert.True(Math.Abs(result) < float.Epsilon);
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
