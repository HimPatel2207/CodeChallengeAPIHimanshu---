import packageJson from '../../package.json'
import {IEnvironment} from './env.types'

export const environment: IEnvironment = {
    production: true,
    apiUrl: 'https://localhost:7199/api/',
    version: '5.0/',
}
