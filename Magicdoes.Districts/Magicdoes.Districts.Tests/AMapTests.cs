using System;
using System.Threading.Tasks;
using Magicdoes.Districts.Amap;
using Xunit;
using Shouldly;
using System.Linq;
using Magicdoes.Districts.Tests.Helper;

namespace Magicdoes.Districts.Tests
{
    public class AMapTests : TestBase
    {
        public AMapTests()
        {
            var settings = TestConfigHelper.LoadConfig("amap");
            DistrictsProvider = new AmapDistrictsProvider(settings.ApiKey);
        }
        [Fact]
        public async Task GetDistricts_TestsAsync()
        {
            var result = await DistrictsProvider.GetDistricts();
            result.ShouldNotBeNull();

            //һ����������ʡ������������34����23��ʡ��5����������4��ֱϽ�С�2���ر��������� ...̨��
            result[0].Children.Count.ShouldBeGreaterThanOrEqualTo(34);

            //�������������ؼ�����������334����294���ؼ��С�7��������30�������ݡ�3���ˣ�
            result[0].Children.Sum(p => p.Children.Count).ShouldBeGreaterThanOrEqualTo(334);

        }

        [Fact]
        public async Task GetDistrictsByKeywords_TestsAsync()
        {
            var result = await DistrictsProvider.GetDistricts("����");
            result.ShouldNotBeNull();

            //��ֹ2017��9��12�գ�����ʡ���ƻ���Ϊ14��������13�ؼ��к�1�����ݣ���122���ؼ�����������35����Ͻ����17���ؼ��С�63���غ�7��������
            result[0].Children.Count.ShouldBeGreaterThanOrEqualTo(14);
            result[0].Children.Sum(p => p.Children.Count).ShouldBeGreaterThanOrEqualTo(122);

        }
    }
}
