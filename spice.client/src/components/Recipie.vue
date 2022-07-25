<template>
<div class="recipie-card" @click="selectRecipie">
 
    <div class="recipe-card-content">
        <img src="https://thiscatdoesnotexist.com" class="img-fluid" alt="">
        <h3 class="">{{ recipie.name }}</h3>
        <p class="">{{ recipie.description }}</p>
        <p>{{recipie.steps}}</p>
    </div>


</div>
</template>


<script>
import {computed, onMounted, ref} from '@vue/runtime-core'
import { AppState } from '../AppState.js'
import { recipiesService } from '../services/RecipiesService.js'
import { logger } from '../utils/Logger.js'

export default {
 props: {
    recipie: {
        type: Object,
        required: true
    }},
    setup(){
        return {
      
          
        }
    }
}
</script>


<style lang="scss" scoped>

</style>