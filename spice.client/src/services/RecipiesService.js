import { AppState } from "../AppState.js";
import { logger } from "../utils/Logger.js";
import { api } from "./AxiosService.js";


class RecipiesService{
    async getAll(){
        const res = await api.get('api/recipies')
        logger.log('getRecipies', res.data)
        AppState.recipies = res.data
}
async getIngredients(id){
    const res = await api.get(`api/recipies/${id}/ingredients`)
    logger.log('getIngredients', res.data)
    AppState.ingredients = res.data
}
async getSteps(id){
    const res = await api.get(`api/recipies/${id}/steps`)
    logger.log('getSteps', res.data)
    AppState.steps = res.data
}
}

export const recipiesService = new RecipiesService()