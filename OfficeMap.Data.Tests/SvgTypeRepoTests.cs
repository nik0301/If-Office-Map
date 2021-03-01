using OfficeMap.Data.Models;
using Xunit;

namespace OfficeMap.Data.Tests
{
    public class SvgTypeRepoTests : AbstractBaseTests
    {
        private readonly SvgTypeRepo repo;

        public SvgTypeRepoTests()
        {
            repo = new SvgTypeRepo(GetDbOptions());
        }

        public SvgType AddNewSvgType()
        {
            var svgType = repo.GetById("test svg");

            if (svgType == null)
            {

                svgType = new SvgType
                {
                    Id = "test svg",
                    Draw = "M 1 1 l 20 0",
                    FillColor = "#ffffff",
                    Name = "workplace",
                    StrokeColor = "#000000",
                    Height = 2,
                    Width = 20
                };

                repo.Add(svgType);
            }

            return svgType;
        }

        [Fact]
        public void When_new_svg_type_added_Then_it_can_be_loaded_from_db()
        {
            var svgType = AddNewSvgType();

            var svgTypeFromDb = repo.GetById(svgType.Id);

            Assert.Equal(svgType.Draw, svgTypeFromDb.Draw);
            Assert.Equal(svgType.FillColor, svgTypeFromDb.FillColor);
            Assert.Equal(svgType.Name, svgTypeFromDb.Name);
            Assert.Equal(svgType.StrokeColor, svgTypeFromDb.StrokeColor);
            Assert.Equal(svgType.Height, svgTypeFromDb.Height);
            Assert.Equal(svgType.Width, svgTypeFromDb.Width);
        }

        [Fact]
        public void When_svg_type_updated_Then_it_with_new_data_can_be_loaded_from_db()
        {
            var svgType = AddNewSvgType();

            svgType.Draw = "M 1 1 l 10 10";
            svgType.FillColor = "#000000";
            svgType.StrokeColor = "#ffffff";

            repo.Update(svgType);

            var svgTypeFromDb = repo.GetById(svgType.Id);

            Assert.Equal(svgType.Draw, svgTypeFromDb.Draw);
            Assert.Equal(svgType.FillColor, svgTypeFromDb.FillColor);     
            Assert.Equal(svgType.StrokeColor, svgTypeFromDb.StrokeColor);
        }
    }
}