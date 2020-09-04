using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using Ibge.Domain.Infra.Repositories;
using Ibge.Domain.RegionIbgeContext.Entities;
using Ibge.Domain.RegionIbgeContext.Enums;
using Ibge.Domain.RegionIbgeContext.Mapping;
using Ibge.Domain.RegionIbgeContext.Repositories;
using Ibge.Domain.RegionIbgeContext.ValueObject;
using Ibge.Domain.Tests.Data;
using Microsoft.EntityFrameworkCore;
using Xunit;

namespace Ibge.Domain.Tests.RegionIbgeContextTest.Domain
{
    public class RegionDiffTests
    {
        IEnumerable<Region> local;
        IEnumerable<Region> localWhithoutFirstItem;
        IEnumerable<Region> localDifferent;
        IEnumerable<Region> ibge;
        IEnumerable<Region> ibgeWhithoutFirstItem;

        public RegionDiffTests()
        {
            local = new List<Region>(){
                new Region(1, "N", "Norte"),
                new Region(2, "NE", "Nordeste"),
                new Region(3, "SE", "Sudeste"),
                new Region(4, "S", "Sul"),
                new Region(5, "CO", "Centro-Oeste")
            };
            localDifferent = new List<Region>(){
                new Region(1, "V", "Vorte"),
                new Region(2, "NE", "Nordeste"),
                new Region(3, "SE", "Sudeste"),
                new Region(4, "S", "Sul"),
                new Region(5, "CO", "Centro-Oeste")
            };
            localWhithoutFirstItem = new List<Region>(){
                new Region(2, "NE", "Nordeste"),
                new Region(3, "SE", "Sudeste"),
                new Region(4, "S", "Sul"),
                new Region(5, "CO", "Centro-Oeste")
            };
            ibge = new List<Region>(){
                new Region(1, "N", "Norte"),
                new Region(2, "NE", "Nordeste"),
                new Region(3, "SE", "Sudeste"),
                new Region(4, "S", "Sul"),
                new Region(5, "CO", "Centro-Oeste")
            };
            ibgeWhithoutFirstItem = new List<Region>(){
                new Region(2, "NE", "Nordeste"),
                new Region(3, "SE", "Sudeste"),
                new Region(4, "S", "Sul"),
                new Region(5, "CO", "Centro-Oeste")
            };

        }

        [Fact]
        public void DadoDuasListasIdenticas()
        {
            var regionDiff = new RegionDiff(local, ibge);
            var result = regionDiff.GetDiffs().ToList();
            Assert.Empty(result);
        }
        [Fact]
        public void DadoDuasListasDiferentes()
        {
            var regionDiff = new RegionDiff(localDifferent, ibge);
            var result = regionDiff.GetDiffs().ToList();
            Assert.NotEmpty(result);
        }
        [Fact]
        public void DadoUmaDiferencaLocalNaSigla()
        {
            var regionDiff = new RegionDiff(localDifferent, ibge);
            var result = regionDiff.GetDiffs().First();
            Assert.Equal("V", result.Initials.Local);
        }
        [Fact]
        public void DadoUmaDiferencaIbgelNaSigla()
        {
            var regionDiff = new RegionDiff(localDifferent, ibge);
            var result = regionDiff.GetDiffs().First();
            Assert.NotEqual("V", result.Initials.Ibge);
        }
        [Fact]
        public void DadoUmaDiferencaLocalNoNome()
        {
            var regionDiff = new RegionDiff(localDifferent, ibge);
            var result = regionDiff.GetDiffs().First();
            Assert.Equal("Vorte", result.Name.Local);
        }
        [Fact]
        public void DadoUmaDiferencaIbgelNoNome()
        {
            var regionDiff = new RegionDiff(localDifferent, ibge);
            var result = regionDiff.GetDiffs().First();
            Assert.NotEqual("Vorte", result.Name.Ibge);
        }
        [Fact]
        public void DadoUmaDiferencaAsIdsSaoIdenticas()
        {
            var regionDiff = new RegionDiff(localDifferent, ibge);
            var result = regionDiff.GetDiffs().First();
            Assert.Equal(1, result.Id);
        }
        [Fact]
        public void DadoAListaLocalSemUmItem()
        {
            var regionDiff = new RegionDiff(localWhithoutFirstItem, ibge);
            var result = regionDiff.GetNonexistentInLocal().ToList();
            Assert.NotEmpty(result);
        }
        [Fact]
        public void DadoAListaIbgeSemUmItem()
        {
            var regionDiff = new RegionDiff(local, ibgeWhithoutFirstItem);
            var result = regionDiff.GetNonexistentsInIbge().ToList();
            Assert.NotEmpty(result);
        }

    }
}