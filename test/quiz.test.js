const { calculateGrade, calculatePercentage, isPassed } = require("../script");

test("Grade calculation logic", () => {
  expect(calculateGrade(85)).toBe("A");
});

test("Score percentage calculation", () => {
  expect(calculatePercentage(8, 10)).toBe(80);
});

test("Pass/Fail determination logic", () => {
  expect(isPassed(60)).toBe(true);
});