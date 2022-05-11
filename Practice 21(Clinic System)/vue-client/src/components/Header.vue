<script lang="js">
export default{
    props: {
        isLoggedIn: Boolean,
        isAdmin: Boolean,
    }
}
</script>



<template>
    <Transition>
        <nav class="navbar navbar-expand-lg navbar-dark bg-dark">
            <div class="container-fluid">
                <a class="navbar-brand" href="/">Clinic System</a>
                <button class="navbar-toggler" type="button" data-bs-toggle="collapse"
                    data-bs-target="#navbarSupportedContent" aria-controls="navbarSupportedContent"
                    aria-expanded="false" aria-label="Toggle navigation">
                    <span class="navbar-toggler-icon"></span>
                </button>
                <div class="collapse navbar-collapse" id="navbarSupportedContent" v-if="isLoggedIn">
                    <ul class="navbar-nav me-auto mb-2 mb-lg-0">
                        <li class="nav-item">
                            <a class="nav-link" href="/patients" id="navbar" role="button"
                                data-bs-toggle=" " aria-expanded="false">
                                Patients
                            </a>
                        </li>
                        <li class="nav-item">
                            <a class="nav-link" href="/doctors" id="navbar" role="button"
                                data-bs-toggle=" " aria-expanded="false">
                                Doctors
                            </a>
                        </li>
                        <li class="nav-item">
                            <a class="nav-link" href="/appointments" id="navbar" role="button"
                                data-bs-toggle=" " aria-expanded="false">
                                Appointments
                            </a>
                        </li>
                        <li class="nav-item" v-if="isAdmin">
                            <a class="nav-link" href="/users" id="navbar" role="button" 
                                data-bs-toggle=" " aria-expanded="false">
                                Users
                            </a>
                        </li>
                    </ul>
                    <form class="d-flex">
                        <input class="form-control me-2" type="search" placeholder="Search" aria-label="Search" style="color: black !important;" />
                        <button class="btn btn-outline-success" type="submit">
                            Search
                        </button>
                    </form>
                </div>
            </div>
        </nav>
    </Transition>
</template>

