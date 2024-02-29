async function getAllMealsAsyncAwait() {
  const resStream = await fetch("https://localhost:7023/api/Meal");
  const resBody = await resStream.json();
  populateMealGrid(resBody);
}
function createMealCard(meal) {
  return `
    <div class="col-md-3 mb-4">
      <div class="card">
        <img src="${meal.strMealThumb}" class="card-img-top" alt="${meal.strMeal}">
        <div class="card-body">
          <h5 class="card-title">${meal.strMeal}</h5>
          <a href="${meal.link}" class="btn btn-primary">View Details</a>
        </div>
      </div>
    </div>
  `;
}

function populateMealGrid(resBody) {
  const mealGrid = document.getElementById("mealGrid");
  resBody.meals.forEach((meal) => {
    const cardHtml = createMealCard(meal);
    mealGrid.innerHTML += cardHtml;
  });
}

document.addEventListener("DOMContentLoaded", function () {
  getAllMealsAsyncAwait();
  getbreakfastAsyncAwait();
  getDessertAsyncAwait();
  getMealByIngredient();
});

async function getbreakfastAsyncAwait() {
  const resStream = await fetch("https://localhost:7023/api/Meal/c=breakfast");
  const resBody = await resStream.json();
  populateBreakfastGrid(resBody);
}
function populateBreakfastGrid(resBody) {
  const breakfastGrid = document.getElementById("breakfastGrid");
  resBody.meals.forEach((meal) => {
    const cardHtml = createMealCard(meal);
    breakfastGrid.innerHTML += cardHtml;
  });
}

async function getDessertAsyncAwait() {
  const resStream = await fetch("https://localhost:7023/api/Meal/c=dessert");
  const resBody = await resStream.json();
  populateDessertGrid(resBody);
}
function populateDessertGrid(resBody) {
  const breakfastGrid = document.getElementById("dessertGrid");
  resBody.meals.forEach((meal) => {
    const cardHtml = createMealCard(meal);
    breakfastGrid.innerHTML += cardHtml;
  });
}

async function getMealByIngredient() {
  var searchTerm = document.getElementById("searchBox").value;
  document.getElementById("searchResult").innerHTML +=
    window.location.search.split("=")[1];

  const resStream = await fetch(
    `https://localhost:7023/api/Meal/ing=${
      window.location.search.split("=")[1]
    }`
  );
  const resBody = await resStream.json();
  populateSearchResultGrid(resBody);
}
function populateSearchResultGrid(resBody) {
  const searchResultGrid = document.getElementById("searchResultGrid");
  resBody.meals.forEach((meal) => {
    const cardHtml = createMealCard(meal);
    searchResultGrid.innerHTML += cardHtml;
  });
}
