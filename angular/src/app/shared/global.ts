import { environment } from '../../environments/environment';

export class Global {
    public static HOST: string ='http://localhost:61309'
    public static BASE_ENDPOINT: string = `${Global.HOST}/api`;
}