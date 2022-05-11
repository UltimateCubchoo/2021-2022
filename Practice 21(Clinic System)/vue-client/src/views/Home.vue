<script>
export default {
    props:{
        isLoggedIn: Boolean,
        isAdmin: Boolean,
    }
}
</script>

<template>
    <main>
        <!-- <h1>Home</h1>
        <p>Welcome to the clinic system</p> -->
        <div v-if="!isLoggedIn">
            <h1>Login</h1>
            <p>Username:&nbsp;<input type="text" id="user" ></p>
            <p>Password:&nbsp;<input type="text" id="pass"></p>
            <button class="btn btn-primary" @click="$emit('login')" >Log in</button>
        </div>
        <div v-else>
            <button class="btn btn-danger" @click="$emit('logout')" >Logout</button>
        </div>
    </main>
</template>