export class Member implements IMember {
    id: string;
    name: string;
    sex: number;
    nickName: string;
    phone: string;
    openId: string;
    headImgUrl: string;
    userType: number;
    bindStatus: number;
    bindTime: Date;
    unBindTime: Date;
    integral: number;
    bindStatusName: string;
    userTypeName: string;
    headImgUrlPic: string;

    creationTime: Date;
    constructor(data?: IMember) {
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
            this.name = data["name"];
            this.sex = data["sex"];
            this.nickName = data["nickName"];
            this.phone = data["phone"];
            this.openId = data["openId"];
            this.headImgUrl = data["headImgUrl"];
            this.userType = data["userType"];
            this.bindStatus = data["bindStatus"];
            this.bindTime = data["bindTime"];
            this.unBindTime = data["unBindTime"];
            this.integral = data["integral"];
            this.bindStatusName = data["bindStatusName"];
            this.userTypeName = data["userTypeName"];
            this.headImgUrlPic = data["headImgUrlPic"];

            this.creationTime = data["creationTime"];
        }
    }

    static fromJS(data: any): Member {
        let result = new Member();
        result.init(data);
        return result;
    }

    static fromJSArray(dataArray: any[]): Member[] {
        let array = [];
        dataArray.forEach(result => {
            let item = new Member();
            item.init(result);
            array.push(item);
        });

        return array;
    }

    toJSON(data?: any) {
        data = typeof data === 'object' ? data : {};
        data["id"] = this.id;
        data["name"] = this.name;
        data["sex"] = this.sex;
        data["nickName"] = this.nickName;
        data["phone"] = this.phone;
        data["openId"] = this.openId;
        data["headImgUrl"] = this.headImgUrl;
        data["userType"] = this.userType;
        data["bindStatus"] = this.bindStatus;
        data["bindTime"] = this.bindTime;
        data["unBindTime"] = this.unBindTime;
        data["integral"] = this.integral;

        data["creationTime"] = this.creationTime;
        return data;
    }

    clone() {
        const json = this.toJSON();
        let result = new Member();
        result.init(json);
        return result;
    }
}
export interface IMember {
    id: string;
    name: string;
    sex: number;
    nickName: string;
    phone: string;
    openId: string;
    headImgUrl: string;
    userType: number;
    bindStatus: number;
    bindTime: Date;
    unBindTime: Date;
    integral: number;
    bindStatusName: string;
    userTypeName: string;
    headImgUrlPic: string;

    creationTime: Date;
}