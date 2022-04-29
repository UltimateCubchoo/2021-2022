<template>
    <header>
        <nav class="navbar navbar-expand-lg navbar-dark bg-dark">
            <div class="container-fluid">
                <a class="navbar-brand" href="/">MongoDB</a>
                <button class="navbar-toggler" type="button" data-bs-toggle="collapse"
                    data-bs-target="#navbarSupportedContent" aria-controls="navbarSupportedContent"
                    aria-expanded="false" aria-label="Toggle navigation">
                    <span class="navbar-toggler-icon"></span>
                </button>
                <div class="collapse navbar-collapse" id="navbarSupportedContent">

                    <ul class="navbar-nav me-auto mb-2 mb-lg-0">
                        <li class="nav-item">
                            <a class="nav-link  " href="/client_view" id="navbar " role="button"
                                data-bs-toggle=" " aria-expanded="false">
                                Clients
                            </a>
                        </li>
                        <li class="nav-item">
                            <a class="nav-link  " href="/instructor_view" id="navbar " role="button"
                                data-bs-toggle=" " aria-expanded="false">
                                Instructors
                            </a>
                        </li>
                        <li class="nav-item">
                            <a class="nav-link  " href="/group_view" id="navbar " role="button"
                                data-bs-toggle=" " aria-expanded="false">
                                Groups
                            </a>
                        </li>
                        <li class="nav-item">
                            <a class="nav-link  " href="/inscription_view" id="navbar " role="button"
                                data-bs-toggle=" " aria-expanded="false">
                                Inscriptions
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