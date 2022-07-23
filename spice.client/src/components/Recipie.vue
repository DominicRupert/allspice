<template>
<div class="recipie-card" @click="selectRecipie">
    <div class="recipie-card-image">
        <img :src="recipie.image" alt="Recipie Image" />
    </div>
    <div class="recipe-card-content">
        <h3 class="">{{ recipie.name }}</h3>
        <p class="">{{ recipie.description }}</p>
    </div>


</div>
</template>


<script>
export default {
 
    setup(){
        return {
          
        }
    }
}
</script>


<style lang="scss" scoped>

</style>