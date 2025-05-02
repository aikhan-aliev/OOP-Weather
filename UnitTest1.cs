using Assign_2;

namespace TestForLayers
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void VerifyOzoneStabilityUnderSunshine()
        {
            var layer = new OzoneLayer('Z', 100);
            var condition = Sunshine.Instance();
            var result = condition.Apply(layer);
            Assert.AreEqual(100, layer.Thickness, "Ozone should remain stable under Sunshine.");
        }

        [TestMethod]
        public void CheckOzoneReactionToOtherConditions()
        {
            var layer = new OzoneLayer('Z', 100);
            var condition = OtherConditions.Instance();
            var result = condition.Apply(layer);
            Assert.AreEqual(95, layer.Thickness, "Ozone should decrease by 5% under Other Conditions.");
        }

        [TestMethod]
        public void ValidateOzoneIntegrityDuringThunderstorm()
        {
            var layer = new OzoneLayer('Z', 100);
            var condition = Thunderstorm.Instance();
            var result = condition.Apply(layer);
            Assert.AreEqual(100, layer.Thickness, "Ozone should not be affected by Thunderstorm.");
        }

        [TestMethod]
        public void ConfirmOxygenReductionWithSunshine()
        {
            var layer = new OxygenLayer('X', 120);
            var condition = Sunshine.Instance();
            var result = condition.Apply(layer);
            Assert.AreEqual(114, layer.Thickness, "Oxygen should slightly decrease under Sunshine.");
        }

        [TestMethod]
        public void AssessOxygenDiminutionUnderOtherScenarios()
        {
            var layer = new OxygenLayer('X', 120);
            var condition = OtherConditions.Instance();
            var result = condition.Apply(layer);
            Assert.AreEqual(108, layer.Thickness, "Oxygen should reduce by 10% under Other Conditions.");
        }

        [TestMethod]
        public void ExamineOxygenBehaviorInThunderstorms()
        {
            var layer = new OxygenLayer('X', 120);
            var condition = Thunderstorm.Instance();
            var result = condition.Apply(layer);
            Assert.AreEqual(60, layer.Thickness, "Oxygen should be halved under Thunderstorm.");
        }

        [TestMethod]
        public void TestCarbonDioxideStabilityInThunderstorms()
        {
            var layer = new CarbonLayer('C', 50);
            var condition = Thunderstorm.Instance();
            var result = condition.Apply(layer);
            Assert.AreEqual(50, layer.Thickness, "CO2 should remain unchanged under Thunderstorm.");
        }

        [TestMethod]
        public void EvaluateCarbonDioxideDecreaseUnderSunshine()
        {
            var layer = new CarbonLayer('C', 50);
            var condition = Sunshine.Instance();
            var result = condition.Apply(layer);
            Assert.AreEqual(47.5, layer.Thickness, "CO2 should decrease under Sunshine.");
        }

        [TestMethod]
        public void CheckCarbonDioxideReactionToOtherConditions()
        {
            var layer = new CarbonLayer('C', 50);
            var condition = OtherConditions.Instance();
            var result = condition.Apply(layer);
            Assert.AreEqual(50, layer.Thickness, "CO2 should not change under Other Conditions.");
        }

        [TestMethod]
        public void EvaluateLayerThicknessValidity()
        {
            Assert.IsTrue(new OxygenLayer('X', 1).isOkay(), "Thickness of 1 should be valid.");
            Assert.IsFalse(new OxygenLayer('X', 0.3).isOkay(), "Thickness below 0.5 should be invalid.");
        }
    }
}
