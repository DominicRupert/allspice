import { AppState } from "../AppState.js";
import { logger } from "../utils/Logger.js";
import { api } from "./AxiosService.js";


class RecipiesService{
    async getRecipies(query = ''){
        const res = await api.get('api/recipies' + query)
        logger.log('getRecipies', res.data)
        AppState.recipies = res.data
}
}

export const recipiesService = new RecipiesService()