function calculateGrade(scorePercentage) {
  if (scorePercentage >= 90) return "A";
  if (scorePercentage >= 75) return "B";
  if (scorePercentage >= 50) return "C";
  return "F";
}

function calculatePercentage(score, total) {
  return (score / total) * 100;
}

function isPassed(scorePercentage) {
  return scorePercentage >= 50;
}

test("Grade calculation logic", () => {
  expect(calculateGrade(95)).toBe("A");
});

test("Score percentage calculation", () => {
  expect(calculatePercentage(4, 5)).toBe(80);
});

test("Pass/Fail determination logic", () => {
  expect(isPassed(80)).toBe(true);
});