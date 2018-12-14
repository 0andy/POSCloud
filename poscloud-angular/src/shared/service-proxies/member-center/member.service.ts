import 'rxjs/add/operator/finally';
import 'rxjs/add/operator/map';
import { mergeMap as _observableMergeMap, catchError as _observableCatch } from 'rxjs/operators';
import { Observable, from as _observableFrom, throwError as _observableThrow, of as _observableOf } from 'rxjs';
import { Injectable, Inject, Optional } from '@angular/core';
import { HttpClient } from '@angular/common/http';

import { API_BASE_URL } from '@shared/service-proxies/service-proxies';
import { PosCloudHttpClient } from '../poscloud-httpclient';
import { Member, IntegralDetail } from '@shared/entity/member-center';

@Injectable()
export class MemberServiceProxy {
    private http: HttpClient;
    private _poshttp: PosCloudHttpClient;
    private baseUrl: string;
    protected jsonParseReviver: ((key: string, value: any) => any) | undefined = undefined;

    constructor(@Inject(HttpClient) http: HttpClient, @Inject(PosCloudHttpClient) poshttp: PosCloudHttpClient, @Optional() @Inject(API_BASE_URL) baseUrl?: string) {
        this.http = http;
        this.baseUrl = baseUrl ? baseUrl : "";
        this._poshttp = poshttp;
    }

    getMemberListAsync(params: any): Observable<PagedResultDtoOfMember> {
        let url_ = "/api/services/app/Member/GetPagedMemberListAsync";
        return this._poshttp.get(url_, params).map(data => {
            if (data) {
                return PagedResultDtoOfMember.fromJS(data);
            } else {
                return null;
            }
        });
    }

    getIntegralListByIdAsync(params: any): Observable<PagedResultDtoOfIntegralDetail> {
        let url_ = "/api/services/app/IntegralDetail/GetPagedIntegralListByIdAsync";
        return this._poshttp.get(url_, params).map(data => {
            if (data) {
                return PagedResultDtoOfIntegralDetail.fromJS(data);
            } else {
                return null;
            }
        });
    }

    getMemberByIdAsync(params: any): Observable<Member> {
        let url_ = "/api/services/app/Member/GetMemberByIdAsync";
        return this._poshttp.get(url_, params).map(data => {
            if (data) {
                return Member.fromJS(data);
            } else {
                return null;
            }
        });
    }
}

export class PagedResultDtoOfMember implements IPagedResultDtoOfMember {
    totalCount: number;
    items: Member[];

    constructor(data?: IPagedResultDtoOfMember) {
        if (data) {
            for (var property in data) {
                if (data.hasOwnProperty(property))
                    (<any>this)[property] = (<any>data)[property];
            }
        }
    }

    init(data?: any) {
        if (data) {
            this.totalCount = data["totalCount"];
            if (data["items"] && data["items"].constructor === Array) {
                this.items = [];
                for (let item of data["items"])
                    this.items.push(Member.fromJS(item));
            }
        }
    }

    static fromJS(data: any): PagedResultDtoOfMember {
        let result = new PagedResultDtoOfMember();
        result.init(data);
        return result;
    }

    toJSON(data?: any) {
        data = typeof data === 'object' ? data : {};
        data["totalCount"] = this.totalCount;
        if (this.items && this.items.constructor === Array) {
            data["items"] = [];
            for (let item of this.items)
                data["items"].push(item.toJSON());
        }
        return data;
    }

    clone() {
        const json = this.toJSON();
        let result = new PagedResultDtoOfMember();
        result.init(json);
        return result;
    }
}

export interface IPagedResultDtoOfMember {
    totalCount: number;
    items: Member[];
}

export class PagedResultDtoOfIntegralDetail implements IPagedResultDtoOfIntegralDetail {
    totalCount: number;
    items: IntegralDetail[];

    constructor(data?: IPagedResultDtoOfIntegralDetail) {
        if (data) {
            for (var property in data) {
                if (data.hasOwnProperty(property))
                    (<any>this)[property] = (<any>data)[property];
            }
        }
    }

    init(data?: any) {
        if (data) {
            this.totalCount = data["totalCount"];
            if (data["items"] && data["items"].constructor === Array) {
                this.items = [];
                for (let item of data["items"])
                    this.items.push(IntegralDetail.fromJS(item));
            }
        }
    }

    static fromJS(data: any): PagedResultDtoOfIntegralDetail {
        let result = new PagedResultDtoOfIntegralDetail();
        result.init(data);
        return result;
    }

    toJSON(data?: any) {
        data = typeof data === 'object' ? data : {};
        data["totalCount"] = this.totalCount;
        if (this.items && this.items.constructor === Array) {
            data["items"] = [];
            for (let item of this.items)
                data["items"].push(item.toJSON());
        }
        return data;
    }

    clone() {
        const json = this.toJSON();
        let result = new PagedResultDtoOfIntegralDetail();
        result.init(json);
        return result;
    }
}

export interface IPagedResultDtoOfIntegralDetail {
    totalCount: number;
    items: IntegralDetail[];
}