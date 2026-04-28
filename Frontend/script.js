function checkLogin() {
  const student = localStorage.getItem("student");
  if (!student && !window.location.pathname.includes("index.html")) {
    window.location.href = "index.html";
  }
}

async function registerUser() {
  const username = document.getElementById("username").value.trim();
  const email = document.getElementById("email").value.trim();
  const password = document.getElementById("password").value.trim();

  if (!username || !email || !password) {
    alert("Please fill all fields");
    return;
  }

  try {
    const response = await fetch("http://localhost:5000/api/Users/register", {
      method: "POST",
      headers: {
        "Content-Type": "application/json"
      },
      body: JSON.stringify({
        fullName: username,
        email: email,
        password: password
      })
    });

    if (!response.ok) {
      const errorText = await response.text();
      alert("Registration failed: " + errorText);
      return;
    }

    const data = await response.json();

    localStorage.setItem("student", data.fullName);
    localStorage.setItem("email", data.email);
    localStorage.setItem("userId", data.userId);

    alert("Registration successful");
    window.location.href = "dashboard.html";
  } catch (error) {
    alert("Backend not connected or server not running");
    console.error(error);
  }
}

function logout() {
  localStorage.clear();
  window.location.href = "index.html";
}