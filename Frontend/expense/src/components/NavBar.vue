<template>
  <header>
    <div class="wrapper">
      <nav class="navbar navbar-expand-lg">
        <div class="container-fluid">
          <div>              
              <RouterLink class="navbar-brand" to="/"><i class="bi bi-house" style="padding-top: 3px"></i> &nbsp;Home</RouterLink>
          </div>

          <button class="navbar-toggler" type="button" data-bs-toggle="collapse" data-bs-target="#navbarCollapse" aria-controls="navbarCollapse" aria-expanded="false" aria-label="Toggle navigation">
            <span class="navbar-toggler-icon"></span>
          </button>

          <div class="collapse navbar-collapse" id="navbarCollapse">
            <ul class="navbar-nav ms-1 mb-2 mb-lg-0"> <!-- Use 'ms-auto' to align to the right -->
              <li class="nav-item dropdown active">
                <a class="nav-link dropdown-toggle" href="#" role="button" data-bs-toggle="dropdown" aria-expanded="false">
                    Expenses
                </a>
                <ul class="dropdown-menu dropdown-menu">
                  <li><RouterLink class="dropdown-item" to="/Expense">Expenses</RouterLink></li>
                  <li><hr class="dropdown-divider"></li>
                  <li><RouterLink class="dropdown-item" to="/Expense/new">Create a new Expense</RouterLink></li>
                </ul>
              </li>
            </ul>
          </div>
          <div class="collapse navbar-collapse" id="navbarCollapse">
            <ul class="navbar-nav ms-1 mb-2 mb-lg-0"> <!-- Use 'ms-auto' to align to the right -->
              <li class="nav-item dropdown active">
                <a class="nav-link dropdown-toggle" href="#" role="button" data-bs-toggle="dropdown" aria-expanded="false">
                    Expenses Categories
                </a>
                <ul class="dropdown-menu dropdown-menu">
                  <li><RouterLink class="dropdown-item" to="/ExpenseCategory">Expenses Categories</RouterLink></li>
                  <li><hr class="dropdown-divider"></li>
                  <li><RouterLink class="dropdown-item" to="/ExpenseCategory/new">Create a new Expense Category</RouterLink></li>
                </ul>
              </li>
            </ul>
          </div>
        </div>
      </nav>
    </div>
  </header>
</template>