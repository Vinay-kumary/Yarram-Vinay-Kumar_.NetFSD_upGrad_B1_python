const courses = [
  {
    name: "HTML",
    lessons: ["Intro", "Tags", "Forms"],
    video: "https://www.youtube.com/embed/qz0aGYrrlhU"
  },
  {
    name: "CSS",
    lessons: ["Selectors", "Flexbox", "Grid"],
    video: "https://www.youtube.com/embed/yfoY53QXEnI"
  },
  {
    name: "JavaScript",
    lessons: ["Variables", "Functions", "DOM"],
    video: "https://www.youtube.com/embed/W6NZfCO5SIk"
  }
];

function initializeProgress() {
  const courseNames = ["HTML", "CSS", "JavaScript"];

  courseNames.forEach(name => {
    if (localStorage.getItem(name + "_video") === null) {
      localStorage.setItem(name + "_video", "false");
    }
    if (localStorage.getItem(name + "_quiz") === null) {
      localStorage.setItem(name + "_quiz", "false");
    }
  });

  if (localStorage.getItem("score") === null) {
    localStorage.setItem("score", "0");
  }
  if (localStorage.getItem("grade") === null) {
    localStorage.setItem("grade", "-");
  }
  if (localStorage.getItem("feedback") === null) {
    localStorage.setItem("feedback", "Not Attempted");
  }
}

function checkLogin() {
  const name = localStorage.getItem("student");
  if (!name) {
    window.location.href = "index.html";
  }
}

function logout() {
  const username = localStorage.getItem("student") || "User";
  sessionStorage.setItem("logoutMessage", username + " Successfully Logout");
  localStorage.clear();
  window.location.href = "index.html";
}

function getCourseProgress(courseName) {
  const videoDone = localStorage.getItem(courseName + "_video") === "true";
  const quizDone = localStorage.getItem(courseName + "_quiz") === "true";

  let progress = 0;
  if (videoDone) progress += 50;
  if (quizDone) progress += 50;

  return progress;
}

function calculatePercentage(score, total) {
  return Math.round((score / total) * 100);
}

function calculateGrade(percentage) {
  if (percentage >= 80) {
    return "A";
  } else if (percentage >= 60) {
    return "B";
  } else {
    return "C";
  }
}

function getFeedback(grade) {
  switch (grade) {
    case "A":
      return "Excellent Performance";
    case "B":
      return "Good Job";
    case "C":
      return "Needs Improvement";
    default:
      return "Not Attempted";
  }
}

function isPassed(percentage) {
  return percentage >= 60;
}

if (typeof module !== "undefined" && module.exports) {
  module.exports = {
    calculateGrade,
    calculatePercentage,
    isPassed
  };
}
const quizQuestions = [
  {
    question: "HTML stands for?",
    options: ["Hyper Text Markup Language", "Hyper Tool Markup Language", "Hyperlinks Text Mark Language"],
    answer: "Hyper Text Markup Language"
  },
  {
    question: "Which CSS property controls text color?",
    options: ["font-style", "color", "text-decoration"],
    answer: "color"
  },
  {
    question: "JavaScript is used for?",
    options: ["Styling webpages", "Database management", "Making webpages interactive"],
    answer: "Making webpages interactive"
  },
  {
    question: "Which tag is used for a hyperlink in HTML?",
    options: ["link", "a", "href"],
    answer: "a"
  },
  {
    question: "Which CSS layout system is one-dimensional?",
    options: ["Grid", "Flexbox", "Float"],
    answer: "Flexbox"
  },
  {
    question: "Which JavaScript keyword declares a variable?",
    options: ["let", "define", "varname"],
    answer: "let"
  },
  {
    question: "Which HTML tag displays an image?",
    options: ["image", "img", "pic"],
    answer: "img"
  },
  {
    question: "Which JavaScript method selects an element by ID?",
    options: ["querySelectorAll", "getElementById", "getElementsClass"],
    answer: "getElementById"
  },
  {
    question: "Which CSS property controls spacing inside an element?",
    options: ["margin", "padding", "border"],
    answer: "padding"
  },
  {
    question: "Which symbol is used for comments in JavaScript?",
    options: ["//", "##", "**"],
    answer: "//"
  }
];

function handleOptionChange() {
  const result = document.getElementById("result");
  if (result) {
    result.innerHTML = "";
  }
}

function loadQuizData() {
  return new Promise((resolve) => {
    setTimeout(() => {
      resolve(quizQuestions);
    }, 1000);
  });
}
if (typeof module !== "undefined" && module.exports) {
  module.exports = {
    calculateGrade,
    calculatePercentage,
    isPassed,
    getFeedback
  };
}