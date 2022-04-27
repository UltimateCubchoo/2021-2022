<template>
    <table id="dataTable">
        <thead>
            <slot name="thead">

            </slot>
        </thead>
        <tbody>
            <slot name="tbody">

            </slot>
        </tbody>
    </table>
</template>

<script>
export default {
    mounted() {
        $("#dataTable").DataTable();
    },
}
</script>