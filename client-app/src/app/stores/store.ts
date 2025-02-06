import { createContext, useContext } from "react";
import ActivityStore from "./activityStore";

interface Store {
    activtyStore: ActivityStore
}

export const store: Store = {
    activtyStore: new ActivityStore()
}

export const StoreContext = createContext(store)


export function useStore() {
    return useContext(StoreContext)
}