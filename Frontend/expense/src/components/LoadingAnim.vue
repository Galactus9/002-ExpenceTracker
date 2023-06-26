<template>
    <div class="container2">
        <div>
            <h3>{{LoadingMessage}}</h3>
        </div>
        <div class="loading">
            <span class="ouro ouro3">
                <span class="left"><span class="anim"></span></span>
                <span class="right"><span class="anim"></span></span>
            </span>
        </div>
    </div>

</template>

<script setup>
const props = defineProps({
    LoadingMessage: String
})
</script>

<style scoped>
.container2 {
  display: flex;
  align-items: center;
 /* Align items vertically */
}

.loading {
  margin-left: 10px; /* Adjust the spacing between the two divs */
}
</style>