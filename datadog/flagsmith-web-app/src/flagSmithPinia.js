import { defineStore } from 'pinia'
import flagsmith from 'flagsmith';
import { datadogRum } from '@datadog/browser-rum';

export const flagsDefaultValues = {
    "feature-a": false,
    "feature-b": false,
}

export const flagsTrackKeysValues = {
    "feature-a": true,
    "feature-b": true,
}

export const flagsTrackActionValues = {
    "feature-a": true,
    "feature-b": true,
}


/* eslint-disable */
export const createFlagsProxy = (ffsUpdate = false) => {
    return new Proxy({}, {
        get(target, prop, receiver) {
            if (typeof prop === 'string' && !prop.startsWith('__v_')) {
                return flagsmith.hasFeature(prop);
            }
            return '';
        }
    })
}

/* eslint-disable */
export const flagSmithPinia = {
    install(app, options) {
        flagsmith.init({
            environmentID: 'Yvyc2enxvNtAqviLFsdHzB',
            cacheFlags: true, 
            enableAnalytics: true, 
            onChange: (oldFlags, params) => {
                console.log(params);
                console.log(oldFlags);
                store.flags = createFlagsProxy(true)
            },
            datadogRum: {
                client: datadogRum,
                trackTraits: true,
            },
        });

        const store = useFlagSmithStore();
        store.flags = createFlagsProxy(true)
    }
}

export const useFlagSmithStore = defineStore('flagSmith', {
    state: () => ({
        flags: createFlagsProxy() // with proxy method, states won't be observable in VUE devtool, you can switch to "flags: flagsDefaultValues", but it's not friendly for feature flag usage statistics. You can check localstorage to know the current value of feature flag.
    })
})