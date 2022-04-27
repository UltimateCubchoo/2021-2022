<template>
    <header>
        <nav class="navbar navbar-expand-lg navbar-dark bg-dark">
            <div class="container-fluid">
                <a class="navbar-brand" href="/">Computer Store</a>
                <button class="navbar-toggler" type="button" data-bs-toggle="collapse"
                    data-bs-target="#navbarSupportedContent" aria-controls="navbarSupportedContent"
                    aria-expanded="false" aria-label="Toggle navigation">
                    <span class="navbar-toggler-icon"></span>
                </button>
                <div class="collapse navbar-collapse" id="navbarSupportedContent">

                    <ul class="navbar-nav me-auto mb-2 mb-lg-0">
                        <li class="nav-item">
                            <a class="nav-link  " href="/category_view" id="navbar " role="button"
                                data-bs-toggle=" " aria-expanded="false">
                                Categories
                            </a>
                        </li>

                        <li class="nav-item">
                            <a class="nav-link  " href="/customer_view" id="navbar " role="button"
                                data-bs-toggle=" " aria-expanded="false">
                                Customers
                            </a>
                        </li>

                        <li class="nav-item  ">
                            <a class="nav-link  " href="employee_view" id="navbar " role="button"
                                data-bs-toggle=" " aria-expanded="false">
                                Employees
                            </a>
                        </li>

                        <li class="nav-item  ">
                            <a class="nav-link  " href="order_view" id="navbar " role="button"
                                data-bs-toggle=" " aria-expanded="false">
                                Orders
                            </a>
                        </li>

                        <li class="nav-item  ">
                            <a class="nav-link  " href="product_view" id="navbar " role="button"
                                data-bs-toggle=" " aria-expanded="false">
                                Products
                            </a>
                        </li>

                        <li class="nav-item  ">
                            <a class="nav-link  " href="shipper_view" id="navbar " role="button"
                                data-bs-toggle=" " aria-expanded="false">
                                Shipper
                            </a>
                        </li>

                        <li class="nav-item  ">
                            <a class="nav-link  " href="supplier_view" id="navbar " role="button"
                                data-bs-toggle=" " aria-expanded="false">
                                Supplier
                            </a>
                        </li>

                    </ul>
                    <form class="d-flex">
                        <input class="form-control me-2" type="search" placeholder="Search" aria-label="Search" />
                        <button class="btn btn-outline-success" type="submit">
                            Search
                        </button>
                    </form>
                </div>
            </div>
        </nav>
    </header>
</template>