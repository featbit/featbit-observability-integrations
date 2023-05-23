import fbClient from "featbit-js-client-sdk";
import { defineStore } from 'pinia'

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

// This helps VUE project to do feature flag usage statistics, this also helps implement an easy way of bootstrap
export const createFlagsProxy = (ffsUpdate = false) => {
    return new Proxy({}, {
        /* eslint-disable */
        get(target, prop, receiver) {
            if (typeof prop === 'string' && !prop.startsWith('__v_')) {
                var variant = fbClient.variation(prop, flagsDefaultValues[prop] || '');

                if (ffsUpdate === true && variant) {
                    if (flagsTrackKeysValues[prop] && flagsTrackKeysValues[prop] === variant) {
                        window.DATAFLUX_RUM && window.DATAFLUX_RUM.addRumGlobalContext('track-ff-' + prop, variant);
                        console.log(window.DATAFLUX_RUM && DATAFLUX_RUM.getRumGlobalContext());
                    }
                }

                if (flagsTrackActionValues[prop] && flagsTrackActionValues[prop] === variant) {
                    window.DATAFLUX_RUM && window.DATAFLUX_RUM.addAction('FeatBit Call FFs', {
                        FeatBitProject: window.featbitProject,
                        FeatBitEnv: window.featbitEnv,
                        FeatBitUserInfo: window.currentFFUser,
                        FeatBitFFVariant: '' + variant,
                        FeatBitFFKey: prop,
                    });
                    console.log(`ffCall ${prop}: ${variant}`);
                }
                return variant
            }
            return '';
        }
    })
}

export const featBit = {
    install(app, options) {
        window.featbitEnv = "production";
        window.featbitProject = "test-web-app";
        window.currentFFUser = {
            keyId: 'guance-fake-user-0000001',
            name: 'guance user 0000001',
            customizedProperties: [
                {
                    "name": "orgId",
                    "value": "guance-org-0000001"
                }
            ]
        };
        fbClient.init({
            secret: "z4nZw2HYDkCGnB09R12TnAKIvcqEmwcUK-2mWFtGURaQ",
            api: "https://featbit-tio-eu-eval.azurewebsites.net",
            user: window.currentFFUser
        });

        const store = useFeatBitStore()

        fbClient.on("ff_update", (changes) => {
            changes.length ? store.flags = createFlagsProxy(true) : null;
        });

        fbClient.waitUntilReady().then((changes) => changes.length ? store.flags = createFlagsProxy(true) : null);
    }
}

export const useFeatBitStore = defineStore('featbit', {
    state: () => ({
        flags: createFlagsProxy() // with proxy method, states won't be observable in VUE devtool, you can switch to "flags: flagsDefaultValues", but it's not friendly for feature flag usage statistics. You can check localstorage to know the current value of feature flag.
    })
})