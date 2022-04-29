<script lang="ts">
import {defineComponent} from 'vue'
export default defineComponent({

});
</script>


<template>
<div>
    <h1>Home</h1>
    <button class="btn btn-primary">Create</button><br>
    <button class="btn btn-success">Insert</button><br>
    <button class="btn btn-danger">Delete</button><br>
    <button class="btn btn-warning">Update</button>
</div>
</template>

<style scoped>
    div{
        padding: 3rem;
    }
    button{
        margin: 0;
        margin-bottom: 1rem;
        width: 25rem;
    }
</style>