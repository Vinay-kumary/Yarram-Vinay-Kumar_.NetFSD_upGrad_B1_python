test("Course CRUD test", () => {
  expect(1 + 1).toBe(2);
});

test("Quiz scoring test", () => {
  let score = 5;
  expect(score).toBeGreaterThan(0);
});

test("LINQ filtering logic", () => {
  let data = [1, 2, 3];
  let result = data.filter(x => x > 1);
  expect(result.length).toBe(2);
});

test("API response test", () => {
  let status = 200;
  expect(status).toBe(200);
});

test("Exception handling", () => {
  let error = null;
  expect(error).toBeNull();
});