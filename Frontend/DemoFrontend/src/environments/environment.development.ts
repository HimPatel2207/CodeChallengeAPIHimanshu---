import {IEnvironment} from './env.types'

import packageJson from '../../package.json';

export const environment: IEnvironment = {
    production: false,
    apiUrl: 'https://localhost:7199/api/',
    version: '5.0/',
}
