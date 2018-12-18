export class IntegralDetail implements IIntegralDetail {
    id: string;
    memberId: string;
    initialIntegral: number;
    integral: number;
    finalIntegral: number;
    type: number;
    desc: string;
    shopId: string;
    refId: string;
    typeName: string;
    shopName: string;

    creationTime: Date;
    constructor(data?: IIntegralDetail) {
        if (data) {
            for (var property in data) {
                if (data.hasOwnProperty(property))
                    (<any>this)[property] = (<any>data)[property];
            }
        }
    }

    init(data?: any) {
        if (data) {
            this.id = data["id"];
            this.memberId = data["memberId"];
            this.initialIntegral = data["initialIntegral"];
            this.integral = data["integral"];
            this.finalIntegral = data["finalIntegral"];
            this.type = data["type"];
            this.desc = data["desc"];
            this.shopId = data["shopId"];
            this.refId = data["refId"];
            this.typeName = data["typeName"];
            this.shopName = data["shopName"];

            this.creationTime = data["creationTime"];
        }
    }

    static fromJS(data: any): IntegralDetail {
        let result = new IntegralDetail();
        result.init(data);
        return result;
    }

    static fromJSArray(dataArray: any[]): IntegralDetail[] {
        let array = [];
        dataArray.forEach(result => {
            let item = new IntegralDetail();
            item.init(result);
            array.push(item);
        });

        return array;
    }

    toJSON(data?: any) {
        data = typeof data === 'object' ? data : {};
        data["id"] = this.id;
        data["memberId"] = this.memberId;
        data["initialIntegral"] = this.initialIntegral;
        data["integral"] = this.integral;
        data["finalIntegral"] = this.finalIntegral;
        data["type"] = this.type;
        data["desc"] = this.desc;
        data["shopId"] = this.shopId;
        data["refId"] = this.refId;
        data["typeName"] = this.typeName;
        data["shopName"] = this.shopName;

        data["creationTime"] = this.creationTime;
        return data;
    }

    clone() {
        const json = this.toJSON();
        let result = new IntegralDetail();
        result.init(json);
        return result;
    }
}
export interface IIntegralDetail {
    id: string;
    memberId: string;
    initialIntegral: number;
    integral: number;
    finalIntegral: number;
    type: number;
    desc: string;
    shopId: string;
    refId: string;
    typeName: string;
    shopName: string;

    creationTime: Date;
}