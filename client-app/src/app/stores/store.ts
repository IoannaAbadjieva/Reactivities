import { createContext, useContext } from "react";
import ActivityStore from "./activityStore";
import CommonStore from "./commonStore";

interface Store {
    activtyStore: ActivityStore
    commonStore: CommonStore
}

export const store: Store = {
    activtyStore: new ActivityStore(),
    commonStore: new CommonStore()
}

export const StoreContext = createContext(store)


export function useStore() {
    return useContext(StoreContext)
}