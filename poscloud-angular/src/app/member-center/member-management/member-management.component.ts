import { Component, OnInit, Injector } from '@angular/core';
import { AppComponentBase } from '@shared/app-component-base';
import { Member } from '@shared/entity/member-center';
import { Router } from '@angular/router';
import { PagedResultDtoOfMember, MemberServiceProxy } from '@shared/service-proxies/member-center';
// import { debounceTime, distinctUntilChanged } from 'rxjs/operators';
// import { Subject } from 'rxjs';

@Component({
    moduleId: module.id,
    selector: 'member-management',
    templateUrl: 'member-management.component.html',
    styleUrls: ['member-management.component.less']
})
export class MemberManagementComponent extends AppComponentBase implements OnInit {
    search: any = {};
    loading = false;
    memberList: Member[] = [];
    text: string = '查无此人';
    // endTime: any;
    // private searchText$ = new Subject<string>();
    constructor(injector: Injector
        , private router: Router
        , private memberService: MemberServiceProxy
    ) {
        super(injector);
    }

    ngOnInit(): void {
        this.refreshData();
        // this.searchText$.pipe(
        //     debounceTime(800),
        //     distinctUntilChanged()).subscribe(term => {
        //         this.refreshData();
        //     });
    }
    // onKey(event: KeyboardEvent) {
    //     // if (this.search.filter.length >= 1)
    //     //     this.endTime = event.timeStamp;
    //     // setTimeout(() => {
    //     //     if (this.endTime - event.timeStamp == 0) {
    //     //         this.refreshData();
    //     //     }
    //     // }, 0.5e3);
    //     this.searchText$.next(this.search.filter);
    // }

    refreshData(reset = false, search?: boolean) {
        if (reset) {
            this.query.pageIndex = 1;
            this.search = {}
        }
        if (search) {
            this.query.pageIndex = 1;
        }
        this.loading = true;
        let params: any = {};
        params.SkipCount = this.query.skipCount();
        params.MaxResultCount = this.query.pageSize;
        params.Filter = this.search.filter;
        this.memberService.getMemberListAsync(params).subscribe((result: PagedResultDtoOfMember) => {
            this.loading = false;
            this.memberList = result.items;
            this.query.total = result.totalCount;
        })
    }

    goDetail(id: string) {
        this.router.navigate(['app/member/member-detail', id])
    }
}
